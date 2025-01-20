using Microsoft.Extensions.Logging;
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
    public class SubjectLogic : ISubjectLogic
    {
        private readonly ILogger _logger;
        private readonly ISubjectStorage _subjectStorage;

        public SubjectLogic(ILogger<SubjectLogic> logger, ISubjectStorage subjectStorage)
        {
            _logger = logger;
            _subjectStorage = subjectStorage;
        }

        public List<SubjectViewModel>? ReadList(SubjectSearchModel? model)
        {
            _logger.LogInformation("ReadList. SubjectName:{SubjectName}. Id:{Id}", model?.SubjectName, model?.Id);
            var list = model == null ? _subjectStorage.GetFullList() : _subjectStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public SubjectViewModel? ReadElement(SubjectSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. SubjectName:{SubjectName}. Id:{Id}", model.SubjectName, model.Id);
            var element = _subjectStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(SubjectBindingModel model)
        {
            CheckModel(model);
            if (_subjectStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(SubjectBindingModel model)
        {
            CheckModel(model);
            if (_subjectStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(SubjectBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_subjectStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(SubjectBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.SubjectName))
            {
                throw new ArgumentNullException("Нет названия предмета", nameof(model.SubjectName));
            }
            _logger.LogInformation("Subject. SubjectName:{SubjectName}. Id:{Id}", model.SubjectName, model.Id);
            var element = _subjectStorage.GetElement(new SubjectSearchModel
            {
                SubjectName = model.SubjectName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Предмет с таким названием уже есть");
            }
        }
    }
}
