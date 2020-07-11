package ratelimiting.items.requests

import io.gatling.core.Predef._
import io.gatling.http.Predef._

object BatchUpdate {
  private val requestBody = """[]"""

  val request =
    http("batchUpdate")
      .patch("/api/Catalog")
      .body(StringBody(requestBody)).asJson
      .check(status.is(200))
}
