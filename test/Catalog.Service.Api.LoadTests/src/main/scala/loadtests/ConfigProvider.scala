package loadtests

import loadtests.catalog.BrowseItemsCatalogSimulationConfig
import pureconfig._
import pureconfig.generic.auto._

object ConfigProvider {
  val commons = ConfigSource.file("commons.conf")
    .loadOrThrow[CommonsConfig]

  val browseItemsCatalogSimulation = ConfigSource.file("browseItemsCatalogSimulation.conf")
    .loadOrThrow[BrowseItemsCatalogSimulationConfig]
}
