using Microsoft.Extensions.Logging;
using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.BusinessLogicContracts;
using ScheduleAppContracts.SearchModels;
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
    public partial class FormRoom : Form
    {
        private readonly ILogger _logger;
        private readonly IRoomLogic _logic;
        private int? _id;

        public int Id { set { _id = value; } }

        public FormRoom(ILogger<FormRoom> logger, IRoomLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormRoom_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение аудитории");
                    var view = _logic.ReadElement(new RoomSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxRoomName.Text = view.RoomName;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения аудитории");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxRoomName.Text))
            {
                MessageBox.Show("Заполните название аудитории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Сохранение аудитории");
            try
            {
                var model = new RoomBindingModel
                {
                    Id = _id ?? 0,
                    RoomName = textBoxRoomName.Text
                };

                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения аудитории");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCanelSaveRoom_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
