using Commander.Dtos;
using Commander.Models;
using Riok.Mapperly.Abstractions;

namespace Commander.Mappers;

[Mapper]
internal sealed partial class CommandMapper
{
    internal partial CommandReadResponse CommandToCommandReadResponse(Command command);
    internal partial IEnumerable<CommandReadResponse> CommandToCommandReadResponse(IEnumerable<Command> commands);
    internal partial Command CommandCreateRequestToCommand(CommandCreateRequest dto);
}
