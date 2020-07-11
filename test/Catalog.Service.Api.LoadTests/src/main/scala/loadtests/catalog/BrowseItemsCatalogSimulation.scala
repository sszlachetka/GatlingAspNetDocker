package loadtests.catalog

import io.gatling.core.Predef._
import io.gatling.http.Predef._
import loadtests.ConfigProvider
import loadtests.catalog.scenarios.{BatchUpdateItems, SearchAndFetchItemsDetails}

class BrowseItemsCatalogSimulation extends Simulation {

  val commonsConfig = ConfigProvider.commons;
  val simulationConfig = ConfigProvider.browseItemsCatalogSimulation

  val httpProtocol = http
    .baseUrl(commonsConfig.baseUrl)

  setUp(
    BatchUpdateItems.populationBuilder(simulationConfig.batchUpdateItems),
    SearchAndFetchItemsDetails.populationBuilder(simulationConfig.searchAndFetchItemsDetails)
  ).protocols(httpProtocol).maxDuration(simulationConfig.maxDuration)
}
