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
    public class RoomLogic : IRoomLogic
    {
        private readonly ILogger _logger;
        private readonly IRoomStorage _roomStorage;

        public RoomLogic(ILogger<RoomLogic> logger, IRoomStorage roomStorage)
        {
            _logger = logger;
            _roomStorage = roomStorage;
        }

        public List<RoomViewModel>? ReadList(RoomSearchModel? model)
        {
            _logger.LogInformation("ReadList. RoomName:{RoomName}. Id:{Id}", model?.RoomName, model?.Id);
            var list = model == null ? _roomStorage.GetFullList() : _roomStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public RoomViewModel? ReadElement(RoomSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. RoomName:{RoomName}. Id:{Id}", model.RoomName, model.Id);
            var element = _roomStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(RoomBindingModel model)
        {
            CheckModel(model);
            if (_roomStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(RoomBindingModel model)
        {
            CheckModel(model);
            if (_roomStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(RoomBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_roomStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(RoomBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.RoomName))
            {
                throw new ArgumentNullException("Нет названия аудитории", nameof(model.RoomName));
            }
            _logger.LogInformation("Room. RoomName:{RoomName}. Id:{Id}", model.RoomName, model.Id);
            var element = _roomStorage.GetElement(new RoomSearchModel
            {
                RoomName = model.RoomName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Аудитория с таким названием уже есть");
            }
        }
    }
}
