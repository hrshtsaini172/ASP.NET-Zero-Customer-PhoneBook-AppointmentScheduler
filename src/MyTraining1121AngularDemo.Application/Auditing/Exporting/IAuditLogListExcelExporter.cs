using System.Collections.Generic;
using MyTraining1121AngularDemo.Auditing.Dto;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
