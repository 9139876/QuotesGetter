using Graal.QuotesGetter.GUI.DataParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graal.QuotesGetter.DataParser.Expressions;
using Graal.Library.Common;
using System.IO;
using Graal.Library.Storage.Common;
using NLog;
using Graal.Library.Common.Enums;
using Graal.Library.Common.GUI;
using System.Text.RegularExpressions;

namespace Graal.QuotesGetter.GUI
{
    public partial class QuotesParserWindow : Form
    {
        StorageManager storageManager;

        public QuotesParserWindow()
        {
            InitializeComponent();

            Lb_Expressions.Items.AddRange(Description.GetAllDescptions<ExpressionType>());
        }

        #region Initial

        private void CheckOnLoad(object sender, EventArgs e)
        {
            //Проверка переменной среды с именем папки
            if (!AppGlobal.EnvironmentIsReady())
            {
                if (!TryInitialEnvironment())
                {
                    MessageBox.Show(new Form() { TopMost = true }, "Не удалось инициализировать среду", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            //Инициализация логгера
            InitialLogger();

            //Создаем менеджер хранилищы
            storageManager = new StorageManager();

            //Проверка полключения к БД
            if (!storageManager.StorageStatus)
            {
                AppGlobal.WarningMessage("Строка подключения к БД не найдена");
                storageManager.ChangeConnectionParameters();

                if (!storageManager.StorageStatus)
                {
                    MessageBox.Show(new Form() { TopMost = true }, "Не удалось подключиться к БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            //Проверка имени схемы
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GraalSchemaName", EnvironmentVariableTarget.User)))
            {
                AppGlobal.WarningMessage("Имя схемы Graal не найдено");

                string schemaName = null;

                var regex = new Regex(@"^[a-z][a-z0-9_]*$");

                using (var ibw = new InputBoxWindow(true, true, false, string.Empty, "Имя схемы", "Имя схемы Graal", (char c) => regex.IsMatch(new string(c, 1))))
                {
                    ibw.GetStr = (string s) => schemaName = s;

                    if (ibw.ShowDialog() == DialogResult.OK)
                    {
                        if (string.IsNullOrEmpty(schemaName))
                        {
                            MessageBox.Show(new Form() { TopMost = true }, "Невозможно создать схему - имя схемы не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }

                        if (!regex.IsMatch(schemaName))
                        {
                            MessageBox.Show(new Form() { TopMost = true }, $"Невозможно создать схему - имя схемы {schemaName} содержит недопустимые символы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }

                        Environment.SetEnvironmentVariable(AppGlobal.EnvironmentVariableGraalSchemaName, schemaName, EnvironmentVariableTarget.User);

                        if (!storageManager.GraalSchemaExistAndCorrect() || MessageBox.Show("Пересоздать схему заново?", "Схема уже существует", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (TryCreateSchema())
                                AppGlobal.InfoMessage("Схема Graal успешно создана в хранилище");
                            else
                                Close();
                        }

                        return;
                    }
                }

                MessageBox.Show(new Form() { TopMost = true }, "Не удалось установить имя схемы Graal", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            //Проверка схемы
            if (!storageManager.GraalSchemaExistAndCorrect())
            {
                MessageBox.Show(new Form() { TopMost = true }, "Схема Graal не найдена в БД либо некорректна и будет создана заново", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (TryCreateSchema())
                    AppGlobal.InfoMessage("Схема Graal успешно создана в хранилище");
                else
                    Close();
            }
        }

        bool TryCreateSchema()
        {
            try
            {
                storageManager.GraalSchemaCreate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, ex.Message, "Ошибка создания схемы Graal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        bool TryInitialEnvironment()
        {
            using (var ofd = new FolderBrowserDialog() { Description = "Выбор рабочей паки Graal" })
            {
                if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.SelectedPath) && Directory.Exists(ofd.SelectedPath))
                {
                    foreach (var path in Enum.GetNames(typeof(GraalTypeFolder)))
                        Directory.CreateDirectory(Path.Combine(ofd.SelectedPath, path));

                    Environment.SetEnvironmentVariable(AppGlobal.EnvironmentVariableGraalDataPathName, ofd.SelectedPath, EnvironmentVariableTarget.User);

                    AppGlobal.InfoMessage("Среда успешно инициализирована");

                    return true;
                }
            }

            return false;
        }

        void InitialLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();

            if (!AppGlobal.TryGetFullPath(GraalTypeFolder.Logs, Path.Combine("QuotesGetter.GUI", $"{Auxiliary.DateTimeNowFile()}.log"), out string path))
                throw new InvalidOperationException("Не удалось получить имя файла для логов");

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = path };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);

            // Apply config
            NLog.LogManager.Configuration = config;

            AppGlobal.Logger = NLog.LogManager.GetLogger("QuotesGetter.GUI");
        }


        #endregion

        private void Lb_Expressions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new CreateExpressionWindow(Description.ValueFromDescription<ExpressionType>(Lb_Expressions.SelectedItem.ToString()), null).ShowDialog();
        }
    }
}
