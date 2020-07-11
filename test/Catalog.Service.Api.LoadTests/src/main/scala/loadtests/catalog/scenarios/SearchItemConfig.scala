package loadtests.catalog.scenarios

import scala.concurrent.duration.FiniteDuration

case class SearchItemConfig(
                             nothingFor: FiniteDuration,
                             rampUsers: Int,
                             rampUsersDuring: FiniteDuration,
                             interval: FiniteDuration)
