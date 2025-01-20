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
    public partial class FormRooms : Form
    {
        private readonly ILogger _logger;
        private readonly IRoomLogic _logic;

        public FormRooms(ILogger<FormRooms> logger, IRoomLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormRooms_Load(object sender, EventArgs e)
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
                    dataGridViewRooms.DataSource = list;
                    dataGridViewRooms.Columns["Id"].Visible = false;
                    dataGridViewRooms.Columns["RoomName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка списка аудиторий");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка аудиторий");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateRoom_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormRoom)) as FormRoom;
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление аудитории");
                    try
                    {
                        if (!_logic.Delete(new RoomBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления аудитории");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonUpdateTheListOfRooms_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
