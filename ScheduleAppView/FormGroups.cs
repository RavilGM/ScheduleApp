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
    public partial class FormGroups : Form
    {
        private readonly ILogger _logger;
        private readonly IGroupLogic _logic;
        public FormGroups(ILogger<FormGroups> logger, IGroupLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }
        private void FormGroups_Load(object sender, EventArgs e)
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
                    dataGridViewGroups.DataSource = list;
                    dataGridViewGroups.Columns["Id"].Visible = false;
                    dataGridViewGroups.Columns["GroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка списка групп");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка групп");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormGroup)) as FormGroup;
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroups.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewGroups.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление группы");
                    try
                    {
                        if (!_logic.Delete(new GroupBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления группы");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonUpdateTheListOfGroups_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridViewGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
