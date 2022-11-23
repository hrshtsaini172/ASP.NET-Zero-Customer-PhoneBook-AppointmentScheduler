using System.Collections.Generic;
using Abp;
using MyTraining1121AngularDemo.Chat.Dto;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
