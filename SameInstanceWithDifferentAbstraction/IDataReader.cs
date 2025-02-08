namespace SameInstanceWithDifferentAbstraction;

internal interface IDataReader
{
    DataModel Get(int id);
}