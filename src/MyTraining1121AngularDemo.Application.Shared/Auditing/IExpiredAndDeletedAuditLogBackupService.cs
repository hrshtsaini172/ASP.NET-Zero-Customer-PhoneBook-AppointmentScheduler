using System.Collections.Generic;
using Abp.Auditing;

namespace MyTraining1121AngularDemo.Auditing
{
    public interface IExpiredAndDeletedAuditLogBackupService
    {
        bool CanBackup();
        
        void Backup(List<AuditLog> auditLogs);
    }
}