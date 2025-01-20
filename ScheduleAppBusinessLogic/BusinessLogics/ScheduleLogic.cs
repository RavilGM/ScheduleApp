using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.BusinessLogicContracts;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppBusinessLogic.BusinessLogics
{
    public class ScheduleLogic : IScheduleLogic
    {
        private readonly ILogger _logger;
        private readonly IScheduleStorage _scheduleStorage;

        public ScheduleLogic(ILogger<ScheduleLogic> logger, IScheduleStorage scheduleStorage)
        {
            _logger = logger;
            _scheduleStorage = scheduleStorage;
        }

        public List<ScheduleViewModel>? ReadList(ScheduleSearchModel? model)
        {
            _logger.LogInformation("ReadList. Date:{Date}. Id:{Id}", model?.Date, model?.Id);
            var list = model == null ? _scheduleStorage.GetFullList() : _scheduleStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public ScheduleViewModel? ReadElement(ScheduleSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. Date:{Date}. Id:{Id}", model.Date, model.Id);
            var element = _scheduleStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(ScheduleBindingModel model)
        {
            CheckModel(model);
            if (_scheduleStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(ScheduleBindingModel model)
        {
            CheckModel(model);
            if (_scheduleStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(ScheduleBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_scheduleStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        public bool ExportToExcel(string fileName)
        {
            try
            {
                // Устанавливаем лицензию для EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Получаем список расписания
                var schedules = _scheduleStorage.GetFullList();
                if (schedules == null || schedules.Count == 0)
                {
                    _logger.LogWarning("Список расписания пуст");
                    throw new Exception("Нет данных для экспорта.");
                }

                // Создаем Excel-пакет
                using (var package = new ExcelPackage())
                {
                    // Добавляем лист в Excel-файл
                    var worksheet = package.Workbook.Worksheets.Add("Расписание");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Дата";
                    worksheet.Cells[1, 2].Value = "Аудитория";
                    worksheet.Cells[1, 3].Value = "Преподаватель";
                    worksheet.Cells[1, 4].Value = "Предмет";
                    worksheet.Cells[1, 5].Value = "Группа";

                    // Заполняем данные
                    for (int i = 0; i < schedules.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = schedules[i].Date.ToShortDateString();
                        worksheet.Cells[i + 2, 2].Value = schedules[i].RoomName;
                        worksheet.Cells[i + 2, 3].Value = schedules[i].TeacherName;
                        worksheet.Cells[i + 2, 4].Value = schedules[i].SubjectName;
                        worksheet.Cells[i + 2, 5].Value = schedules[i].GroupName;
                    }

                    // Автонастройка ширины столбцов
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Сохраняем файл
                    var file = new FileInfo(fileName);
                    package.SaveAs(file);
                }

                _logger.LogInformation("Экспорт в Excel выполнен успешно");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка экспорта в Excel");
                throw new Exception("Ошибка экспорта в Excel", ex);
            }
        }

        private void CheckModel(ScheduleBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.SubjectId <= 0)
            {
                throw new ArgumentNullException("Некорректный ID предмета", nameof(model.SubjectId));
            }
            if (model.RoomId <= 0)
            {
                throw new ArgumentNullException("Некорректный ID аудитории", nameof(model.RoomId));
            }
            if (model.TeacherId <= 0)
            {
                throw new ArgumentNullException("Некорректный ID преподавателя", nameof(model.TeacherId));
            }
            if (model.GroupId <= 0)
            {
                throw new ArgumentNullException("Некорректный ID группы", nameof(model.GroupId));
            }
            if (model.Date == default)
            {
                throw new ArgumentNullException("Некорректная дата", nameof(model.Date));
            }
            _logger.LogInformation("Schedule. SubjectId:{SubjectId}. RoomId:{RoomId}. TeacherId:{TeacherId}. GroupId:{GroupId}. Date:{Date}. Id:{Id}",
                model.SubjectId, model.RoomId, model.TeacherId, model.GroupId, model.Date, model.Id);
        }
    }
}
