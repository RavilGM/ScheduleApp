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
    public partial class FormTeachers : Form
    {
        private readonly ILogger _logger;
        private readonly ITeacherLogic _logic;

        public FormTeachers(ILogger<FormTeachers> logger, ITeacherLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormTeachers_Load(object sender, EventArgs e)
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
                    dataGridViewTeachers.DataSource = list;
                    dataGridViewTeachers.Columns["Id"].Visible = false;
                    dataGridViewTeachers.Columns["TeacherName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка списка преподавателей");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка преподавателей");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateTeacher_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormTeacher)) as FormTeacher;
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeachers.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewTeachers.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление преподавателя");
                    try
                    {
                        if (!_logic.Delete(new TeacherBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления преподавателя");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonUpdateTheListOfTeachers_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
