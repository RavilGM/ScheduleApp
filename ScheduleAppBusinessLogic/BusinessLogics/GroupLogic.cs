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
    public class GroupLogic : IGroupLogic
    {
        private readonly ILogger _logger;
        private readonly IGroupStorage _groupStorage;

        public GroupLogic(ILogger<GroupLogic> logger, IGroupStorage groupStorage)
        {
            _logger = logger;
            _groupStorage = groupStorage;
        }

        public List<GroupViewModel>? ReadList(GroupSearchModel? model)
        {
            _logger.LogInformation("ReadList. GroupName:{GroupName}. Id:{Id}", model?.GroupName, model?.Id);
            var list = model == null ? _groupStorage.GetFullList() : _groupStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public GroupViewModel? ReadElement(GroupSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. GroupName:{GroupName}. Id:{Id}", model.GroupName, model.Id);
            var element = _groupStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(GroupBindingModel model)
        {
            CheckModel(model);
            if (_groupStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(GroupBindingModel model)
        {
            CheckModel(model);
            if (_groupStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(GroupBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_groupStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(GroupBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.GroupName))
            {
                throw new ArgumentNullException("Нет названия группы", nameof(model.GroupName));
            }
            _logger.LogInformation("Group. GroupName:{GroupName}. Id:{Id}", model.GroupName, model.Id);
            var element = _groupStorage.GetElement(new GroupSearchModel
            {
                GroupName = model.GroupName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Группа с таким названием уже есть");
            }
        }
    }
}
