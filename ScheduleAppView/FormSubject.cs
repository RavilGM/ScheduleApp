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
    public partial class FormSubject : Form
    {
        private readonly ILogger _logger;
        private readonly ISubjectLogic _logic;
        private int? _id;

        public int Id { set { _id = value; } }

        public FormSubject(ILogger<FormSubject> logger, ISubjectLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormSubject_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение предмета");
                    var view = _logic.ReadElement(new SubjectSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxSubjectName.Text = view.SubjectName;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения предмета");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveSubject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSubjectName.Text))
            {
                MessageBox.Show("Заполните название предмета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Сохранение предмета");
            try
            {
                var model = new SubjectBindingModel
                {
                    Id = _id ?? 0,
                    SubjectName = textBoxSubjectName.Text
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
                _logger.LogError(ex, "Ошибка сохранения предмета");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCanelSaveSubject_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
