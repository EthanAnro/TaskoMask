﻿using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Project), ResourceType = typeof(DomainMetadata))]
    public class Project : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Project(string name, string description, string organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

      
        #endregion

        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }


        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, string description)
        {
            Description = description;
            Name = name;
        }


        #endregion

        #region Private Methods



        #endregion


    }
}
