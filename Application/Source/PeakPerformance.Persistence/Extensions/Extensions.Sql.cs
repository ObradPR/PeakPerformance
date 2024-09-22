﻿using Microsoft.Data.SqlClient;
using PeakPerformance.Common.Extensions;
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Persistence.Enums;

namespace PeakPerformance.Persistence.Extensions;

public static partial class Extensions
{
    public static void SetIdentityInsert<TEntity>(this SqlConnection connection, eIdentitySwitch identitySwitch = eIdentitySwitch.On, string schema = "dbo")
        where TEntity : _BaseEntity
    {
        var tableName = GetTableName<TEntity>(eTableType.Lookup);

        var sqlSwitch = identitySwitch switch
        {
            eIdentitySwitch.On => eIdentitySwitch.On.GetDescription(),
            eIdentitySwitch.Off => eIdentitySwitch.Off.GetDescription(),
            _ => throw new ArgumentException("Invalid identity switch value.", nameof(identitySwitch)),
        };

        var sql = $"SET IDENTITY_INSERT [{schema}].[{tableName}] {sqlSwitch};";

        using (var command = new SqlCommand(sql, connection))
        {
            command.ExecuteNonQuery();
        }
    }
}