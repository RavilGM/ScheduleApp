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
    public partial class FormGroup : Form
    {
        private readonly ILogger _logger;
        private readonly IGroupLogic _logic;
        private int? _id;

        public int Id { set { _id = value; } }
        public FormGroup(ILogger<FormGroup> logger, IGroupLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }
        private void FormGroup_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение группы");
                    var view = _logic.ReadElement(new GroupSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxGroupName.Text = view.GroupName;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения группы");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void buttonSaveGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGroupName.Text))
            {
                MessageBox.Show("Заполните название группы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Сохранение группы");
            try
            {
                var model = new GroupBindingModel
                {
                    Id = _id ?? 0,
                    GroupName = textBoxGroupName.Text
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
                _logger.LogError(ex, "Ошибка сохранения группы");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCanelSaveGroup_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
