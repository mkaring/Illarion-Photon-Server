namespace Illarion.Server
{
  internal class MapFactory : IMapFactory
  {
    IMap IMapFactory.CreateMap() => new SingleSectorMap();
  }
}
