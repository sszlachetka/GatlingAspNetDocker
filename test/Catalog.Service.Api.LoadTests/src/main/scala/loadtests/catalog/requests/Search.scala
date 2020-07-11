package loadtests.catalog.requests

import io.gatling.core.Predef._
import io.gatling.http.Predef._

object Search {
  val request =
    http("search")
      .get("/api/Catalog")
      .check(status.is(200))
      .check(
        jsonPath("$.items[0].id").saveAs("itemId")
      )
}
