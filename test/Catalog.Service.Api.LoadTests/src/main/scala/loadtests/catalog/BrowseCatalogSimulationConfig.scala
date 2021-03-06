package loadtests.catalog

import loadtests.catalog.scenarios.{BatchUpdateItemsConfig, SearchItemConfig}

import scala.concurrent.duration.FiniteDuration

case class BrowseCatalogSimulationConfig(
                                          maxDuration: FiniteDuration,
                                          searchItem: SearchItemConfig,
                                          batchUpdateItems: BatchUpdateItemsConfig)
