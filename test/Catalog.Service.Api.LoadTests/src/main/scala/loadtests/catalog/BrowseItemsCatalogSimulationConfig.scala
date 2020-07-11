package loadtests.catalog

import loadtests.catalog.scenarios.{BatchUpdateItemsConfig, SearchAndFetchItemsDetailsConfig}

import scala.concurrent.duration.FiniteDuration

case class BrowseItemsCatalogSimulationConfig(
  maxDuration: FiniteDuration,
  searchAndFetchItemsDetails: SearchAndFetchItemsDetailsConfig,
  batchUpdateItems: BatchUpdateItemsConfig)
