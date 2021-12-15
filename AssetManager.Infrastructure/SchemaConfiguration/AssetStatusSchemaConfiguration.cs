using AssetManager.Core;
using AssetManager.Core.Entities.Asset;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Infrastructure.SchemaConfiguration
{
    public class AssetStatusSchemaConfiguration : IEntityTypeConfiguration<AssetStatus>
    {
        public void Configure(EntityTypeBuilder<AssetStatus> builder)
        {
            builder.HasData(
                new AssetStatus { Id = ModelConstants.AssetStatuses.New, Name = "New" },
                new AssetStatus { Id = ModelConstants.AssetStatuses.Assigned, Name = "Assigned" },
                new AssetStatus { Id = ModelConstants.AssetStatuses.Unassigned, Name = "Unassigned" },
                new AssetStatus { Id = ModelConstants.AssetStatuses.Discarded, Name = "Discarded" },
                new AssetStatus { Id = ModelConstants.AssetStatuses.ApprovalPending, Name = "Approval Pending" }
            );
        }
    }
}
