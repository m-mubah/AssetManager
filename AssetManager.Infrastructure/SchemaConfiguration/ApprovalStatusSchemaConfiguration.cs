using AssetManager.Core;
using AssetManager.Core.Entities.Asset.Approval;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Infrastructure.SchemaConfiguration
{
    public class ApprovalStatusSchemaConfiguration : IEntityTypeConfiguration<ApprovalStatus>
    {
        public void Configure(EntityTypeBuilder<ApprovalStatus> builder)
        {
            builder.HasData(
                new ApprovalStatus { Id = ModelConstants.ApprovalStatuses.Pending, Name = "Pending" },
                new ApprovalStatus { Id = ModelConstants.ApprovalStatuses.Approved, Name = "Approved" },
                new ApprovalStatus { Id = ModelConstants.ApprovalStatuses.Rejected, Name = "Rejected" }
            );
        }
    }
}
