package ratelimiting.items

import ratelimiting.items.scenarios.{BatchUpdateItemsConfig, SearchAndFetchItemsDetailsConfig}

import scala.concurrent.duration.FiniteDuration

case class BrowseItemsCatalogSimulationConfig(
  maxDuration: FiniteDuration,
  searchAndFetchItemsDetails: SearchAndFetchItemsDetailsConfig,
  batchUpdateItems: BatchUpdateItemsConfig)
