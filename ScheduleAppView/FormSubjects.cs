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
    public partial class FormSubjects : Form
    {
        private readonly ILogger _logger;
        private readonly ISubjectLogic _logic;

        public FormSubjects(ILogger<FormSubjects> logger, ISubjectLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormSubjects_Load(object sender, EventArgs e)
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
                    dataGridViewSubjects.DataSource = list;
                    dataGridViewSubjects.Columns["Id"].Visible = false;
                    dataGridViewSubjects.Columns["SubjectName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка списка предметов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка предметов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateSubject_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormSubject)) as FormSubject;
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDeleteSubject_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubjects.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewSubjects.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление предмета");
                    try
                    {
                        if (!_logic.Delete(new SubjectBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления предмета");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonUpdateTheListOfSubjects_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
