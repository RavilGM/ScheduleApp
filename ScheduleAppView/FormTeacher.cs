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
    public partial class FormTeacher : Form
    {
        private readonly ILogger _logger;
        private readonly ITeacherLogic _logic;
        private int? _id;

        public int Id { set { _id = value; } }

        public FormTeacher(ILogger<FormTeacher> logger, ITeacherLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение преподавателя");
                    var view = _logic.ReadElement(new TeacherSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxTeacherName.Text = view.TeacherName;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения преподавателя");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveTeacher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTeacherName.Text))
            {
                MessageBox.Show("Заполните имя преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Сохранение преподавателя");
            try
            {
                var model = new TeacherBindingModel
                {
                    Id = _id ?? 0,
                    TeacherName = textBoxTeacherName.Text
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
                _logger.LogError(ex, "Ошибка сохранения преподавателя");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCanelSaveTeacher_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
