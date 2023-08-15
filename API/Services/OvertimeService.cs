using API.Contracts;
using API.DataTransferObjects.Overtimes;

namespace API.Services;

public class OvertimeService
{
    private readonly IOvertimeRepository _overtimeRepository;

    public OvertimeService(IOvertimeRepository overtimeRepository)
    {
        _overtimeRepository = overtimeRepository;
    }

    public IEnumerable<OvertimeDtoGet> Get()
    {
        var overtimes = _overtimeRepository.GetAll().ToList();
        if (!overtimes.Any()) return Enumerable.Empty<OvertimeDtoGet>();
        List<OvertimeDtoGet> overtimeDtoGets = new();

        foreach (var overtime in overtimes)
        {
            overtimeDtoGets.Add((OvertimeDtoGet)overtime);
        }

        return overtimeDtoGets;
    }

    public OvertimeDtoGet? Get(Guid guid)
    {
        var overtime = _overtimeRepository.GetByGuid(guid);
        if (overtime is null) return null;

        return (OvertimeDtoGet)overtime;
    }

    public OvertimeDtoCreate? Create(OvertimeDtoCreate overtimeDtoCreate)
    {
        var overtimeCreated = _overtimeRepository.Create(overtimeDtoCreate);
        if (overtimeCreated is null) return null;

        return (OvertimeDtoCreate)overtimeCreated;
    }

    public int Update(OvertimeDtoUpdate overtimeDtoUpdate)
    {
        var overtime = _overtimeRepository.GetByGuid(overtimeDtoUpdate.Guid);
        if (overtime is null) return -1;

        var overtimeUpdated = _overtimeRepository.Update(overtimeDtoUpdate);
        return overtimeUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var overtime = _overtimeRepository.GetByGuid(guid);
        if (overtime is null) return -1;

        var overtimeDeleted = _overtimeRepository.Delete(overtime);
        return overtimeDeleted ? 1 : 0;
    }
}
