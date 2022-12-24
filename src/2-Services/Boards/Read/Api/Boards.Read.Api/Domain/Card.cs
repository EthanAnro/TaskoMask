﻿using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Boards.Read.Api.Domain
{
    public class Card : BaseEntity
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id Must sync with write side DB</param>
        public Card(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(id)));

            base.SetId(id);
        }


        public string Name { get; set; }
        public BoardCardType Type { get; set; }
        public string BoardId { get; set; }

        //Set this property on publishing related events from the write side
        public string BoardName { get; set; }
        public string ProjectId { get; set; }
        public string OrganizationId { get; set; }
        public string OwnerId { get; set; }


        #region Update private properties


        public void SetAsUpdated()
        {
            base.UpdateModifiedDateTime();
        }

        #endregion
    }
}
