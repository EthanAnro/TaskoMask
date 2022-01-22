﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Application.Workspace.Projects.Services;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;
using TaskoMask.Infrastructure.Data.WriteModel.EventSourcing;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Infrastructure.CrossCutting.Bus;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Application.Membership.Roles.Services;
using TaskoMask.Application.Membership.Operators.Services;
using TaskoMask.Application.Membership.Permissions.Services;
using TaskoMask.Application.Workspace.Owners.Services;
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Workspace.Cards.Services;
using TaskoMask.Application.Workspace.Tasks.Services;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Infrastructure.Data.WriteModel.Repositories.Workspace;
using TaskoMask.Infrastructure.Data.WriteModel.Repositories.Membership;
using TaskoMask.Domain.WriteModel.Membership.Data;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Infrastructure.CrossCutting.Services.Security;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Data;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Data;
using TaskoMask.Domain.WriteModel.Authorization.Data;
using TaskoMask.Infrastructure.Data.WriteModel.Repositories.Authorization;
using TaskoMask.Application.Common.Queries.Models;
using TaskoMask.Application.Common.Queries.Handlers;
using TaskoMask.Application.Common.Commands.Handlers;
using TaskoMask.Application.Common.Commands.Models;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Infrastructure.Data.WriteModel.Services;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;
using TaskoMask.Infrastructure.Data.ReadModel.Repositories;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Services;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;

namespace Infrastructure.CrossCutting.IoC
{

    /// <summary>
    /// 
    /// </summary>
    public static class IoCConfig
    {


        /// <summary>
        /// 
        /// </summary>
        public static void ConfigureIocContainer(this IServiceCollection services)
        {
            #region Application

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            

            #endregion

            #region Infrastructure

            services.AddScoped<IReadDbContext, ReadDbContext>();
            services.AddScoped<IWriteDbContext, WriteDbContext>();
            services.AddScoped<IEventStore, RedisEventStore>();
            services.AddScoped<IInMemoryBus, InMemoryBus>();

            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<ITaskValidatorService, TaskValidatorService>();
            services.AddScoped<IBoardValidatorService, BoardValidatorService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //ReadModel Repositories
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            //Aggregate repositories
            services.AddScoped<IOwnerAggregateRepository, OwnerAggregateRepository>();
            services.AddScoped<IBoardAggregateRepository, BoardAggregateRepository>();
            services.AddScoped<ITaskAggregateRepository, TaskAggregateRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperatorRepository, OperatorRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            

            #endregion

            #region Generic Query Handlers

            //TODO Handel Generic Query Handlers

            services.AddScoped<IRequestHandler<GetCountQuery<Operator>, long>, BaseQueryHandlers<Operator>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Owner>, long>, BaseQueryHandlers<Owner>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Organization>, long>, BaseQueryHandlers<Organization>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Project>, long>, BaseQueryHandlers<Project>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Board>, long>, BaseQueryHandlers<Board>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Task>, long>, BaseQueryHandlers<Task>>();
            services.AddScoped<IRequestHandler<GetCountQuery<Card>, long>, BaseQueryHandlers<Card>>();

            #endregion

            #region Generic Command Handlers

            //TODO Handel Generic Command Handlers

            services.AddScoped<IRequestHandler<DeleteCommand<Operator>, CommandResult>, BaseCommandHandlers<Operator>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Permission>, CommandResult>, BaseCommandHandlers<Permission>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Role>, CommandResult>, BaseCommandHandlers<Role>>();
           
            services.AddScoped<IRequestHandler<DeleteCommand<Member>, CommandResult>, BaseCommandHandlers<Member>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Owner>, CommandResult>, BaseCommandHandlers<Owner>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Organization>, CommandResult>, BaseCommandHandlers<Organization>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Project>, CommandResult>, BaseCommandHandlers<Project>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Board>, CommandResult>, BaseCommandHandlers<Board>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Task>, CommandResult>, BaseCommandHandlers<Task>>();
            services.AddScoped<IRequestHandler<DeleteCommand<Card>, CommandResult>, BaseCommandHandlers<Card>>();

            #endregion
        }
    }
}
