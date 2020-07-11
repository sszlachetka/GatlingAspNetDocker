package ratelimiting.items.scenarios

import scala.concurrent.duration.FiniteDuration

case class SearchAndFetchItemsDetailsConfig(
                                             nothingFor: FiniteDuration,
                                             rampUsers: Int,
                                             rampUsersDuring: FiniteDuration,
                                             interval: FiniteDuration)
