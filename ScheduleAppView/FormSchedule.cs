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
    public partial class FormSchedule : Form
    {
        private readonly ILogger _logger;
        private readonly IScheduleLogic _logic;
        private readonly IRoomLogic _roomLogic;
        private readonly ITeacherLogic _teacherLogic;
        private readonly ISubjectLogic _subjectLogic;
        private readonly IGroupLogic _groupLogic;
        private int? _id;

        public int Id { set { _id = value; } }

        public FormSchedule(ILogger<FormSchedule> logger, IScheduleLogic logic, IRoomLogic roomLogic, ITeacherLogic teacherLogic, ISubjectLogic subjectLogic, IGroupLogic groupLogic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _roomLogic = roomLogic;
            _teacherLogic = teacherLogic;
            _subjectLogic = subjectLogic;
            _groupLogic = groupLogic;
        }

        private void FormSchedule_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение расписания");
                    var view = _logic.ReadElement(new ScheduleSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        dateTimePickerDate.Value = view.Date;
                        comboBoxRoom.SelectedValue = view.RoomId;
                        comboBoxTeacher.SelectedValue = view.TeacherId;
                        comboBoxSubject.SelectedValue = view.SubjectId;
                        comboBoxGroup.SelectedValue = view.GroupId;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения расписания");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                var rooms = _roomLogic.ReadList(null);
                comboBoxRoom.DataSource = rooms;
                comboBoxRoom.DisplayMember = "RoomName";
                comboBoxRoom.ValueMember = "Id";

                var teachers = _teacherLogic.ReadList(null);
                comboBoxTeacher.DataSource = teachers;
                comboBoxTeacher.DisplayMember = "TeacherName";
                comboBoxTeacher.ValueMember = "Id";

                var subjects = _subjectLogic.ReadList(null);
                comboBoxSubject.DataSource = subjects;
                comboBoxSubject.DisplayMember = "SubjectName";
                comboBoxSubject.ValueMember = "Id";

                var groups = _groupLogic.ReadList(null);
                comboBoxGroup.DataSource = groups;
                comboBoxGroup.DisplayMember = "GroupName";
                comboBoxGroup.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки данных для ComboBox");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCanelSaveSchedule_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSaveSchedule_Click(object sender, EventArgs e)
        {
            if (comboBoxRoom.SelectedValue == null || comboBoxTeacher.SelectedValue == null || comboBoxSubject.SelectedValue == null || comboBoxGroup.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Сохранение расписания");
            try
            {
                var model = new ScheduleBindingModel
                {
                    Id = _id ?? 0,
                    Date = dateTimePickerDate.Value,
                    RoomId = Convert.ToInt32(comboBoxRoom.SelectedValue),
                    TeacherId = Convert.ToInt32(comboBoxTeacher.SelectedValue),
                    SubjectId = Convert.ToInt32(comboBoxSubject.SelectedValue),
                    GroupId = Convert.ToInt32(comboBoxGroup.SelectedValue)
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
                _logger.LogError(ex, "Ошибка сохранения расписания");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
