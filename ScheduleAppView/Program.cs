using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using ScheduleAppBusinessLogic.BusinessLogics;
using ScheduleAppContracts.BusinessLogicContracts;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppDataBaseImplement.Implements;
using System;

namespace ScheduleAppView
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ��������� DI
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            // ������ ������� �����
            var mainForm = _serviceProvider.GetRequiredService<FormMain>();
            Application.Run(mainForm);
            
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // ��������� �����������
            services.AddLogging(options =>
            {
                options.SetMinimumLevel(LogLevel.Information);
                options.AddNLog("nlog.config");
            });

            // ����������� ��������
            services.AddTransient<IRoomStorage, RoomStorage>();
            services.AddTransient<ITeacherStorage, TeacherStorage>();
            services.AddTransient<ISubjectStorage, SubjectStorage>();
            services.AddTransient<IGroupStorage, GroupStorage>();
            services.AddTransient<IScheduleStorage, ScheduleStorage>();
            //services.AddTransient<IUserStorage, UserStorage>();

            // ����������� ������-������
            services.AddTransient<IRoomLogic, RoomLogic>();
            services.AddTransient<ITeacherLogic, TeacherLogic>();
            services.AddTransient<ISubjectLogic, SubjectLogic>();
            services.AddTransient<IGroupLogic, GroupLogic>();
            services.AddTransient<IScheduleLogic, ScheduleLogic>();
            services.AddTransient<IUserLogic, UserLogic>();

            // ����������� ����
            services.AddTransient<FormMain>();
            services.AddTransient<FormRoom>();
            services.AddTransient<FormRooms>();
            services.AddTransient<FormTeacher>();
            services.AddTransient<FormTeachers>();
            services.AddTransient<FormSubject>();
            services.AddTransient<FormSubjects>();
            services.AddTransient<FormGroup>();
            services.AddTransient<FormGroups>();
            services.AddTransient<FormSchedule>();
            services.AddTransient<FormSchedules>();
            //services.AddTransient<FormUser>();
        }
    }
}