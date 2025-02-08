namespace SameInstanceWithDifferentAbstraction;

internal class DataProvider : IDataWriter, IDataReader
{
    private readonly List<DataModel> _dataModels = [];

    public void Add(DataModel model) => _dataModels.Add(model);

    public DataModel Get(int id) => _dataModels.Find(x => x.Id == id);
}