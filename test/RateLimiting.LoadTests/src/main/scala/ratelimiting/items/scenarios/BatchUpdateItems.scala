package ratelimiting.items.scenarios

import io.gatling.core.Predef._
import io.gatling.core.Predef.scenario
import io.gatling.core.structure.PopulationBuilder
import ratelimiting.items.requests.BatchUpdate

object BatchUpdateItems {
  def populationBuilder(config: BatchUpdateItemsConfig): PopulationBuilder = {
    scenario("Batch update")
      .forever() {
        exec(BatchUpdate.request)
          .pause(config.interval)
      }.inject(nothingFor(config.nothingFor), rampUsers(config.rampUsers) during config.rampUsersDuring)
  }
}
