package ratelimiting.items.requests

import io.gatling.core.Predef._
import io.gatling.http.Predef._

object Details {
  val request =
    http("details")
      .get("/api/Items/${itemId}")
      .check(status.is(200))
}
