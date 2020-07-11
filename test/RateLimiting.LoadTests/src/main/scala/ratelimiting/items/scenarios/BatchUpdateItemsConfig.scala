package ratelimiting.items.scenarios

import scala.concurrent.duration.FiniteDuration

case class BatchUpdateItemsConfig(
                                   nothingFor: FiniteDuration,
                                   rampUsers: Int,
                                   rampUsersDuring: FiniteDuration,
                                   interval: FiniteDuration)
