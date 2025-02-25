import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];
  baseUrl: string = "http://localhost:4567/mongo/api/";

  constructor(http: HttpClient) {

    http.get<WeatherForecast[]>(this.baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
