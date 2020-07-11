package loadtests.catalog.scenarios

import io.gatling.core.Predef._
import io.gatling.core.Predef.{exec, scenario}
import loadtests.catalog.requests.{Details, Search}
import io.gatling.core.structure.PopulationBuilder
import scala.concurrent.duration._

object SearchAndFetchItemsDetails {
  def populationBuilder(config: SearchAndFetchItemsDetailsConfig): PopulationBuilder = {

    scenario(s"Search catalog")
      .forever() {
        exec(Search.request)
          .pause(1 second)
          .exec(Details.request)
          .pause(config.interval)
      }.inject(nothingFor(config.nothingFor), rampUsers(config.rampUsers) during config.rampUsersDuring)
  }
}
