using Microsoft.Extensions.Logging;
using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.BusinessLogicContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleAppView
{
    public partial class FormSchedules : Form
    {
        private readonly ILogger _logger;
        private readonly IScheduleLogic _logic;

        public FormSchedules(ILogger<FormSchedules> logger, IScheduleLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormSchedules_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.ReadList(null);
                if (list != null)
                {
                    dataGridViewSchedules.DataSource = list;
                    dataGridViewSchedules.Columns["Id"].Visible = false;
                    dataGridViewSchedules.Columns["SubjectName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewSchedules.Columns["RoomName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewSchedules.Columns["TeacherName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewSchedules.Columns["GroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewSchedules.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка списка расписания");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка расписания");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateSchedule_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormSchedule)) as FormSchedule;
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchedules.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewSchedules.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление расписания");
                    try
                    {
                        if (!_logic.Delete(new ScheduleBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления расписания");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonUpdateTheListOfSchedules_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Открываем диалог для выбора места сохранения файла
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Сохранить расписание в Excel"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Вызываем метод экспорта
                    _logic.ExportToExcel(saveFileDialog.FileName);
                    MessageBox.Show("Экспорт в Excel выполнен успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка экспорта в Excel");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
