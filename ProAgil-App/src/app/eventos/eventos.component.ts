import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: any;
  
 // constructor (private http: HttpClient){}

  /*eventos: any =
  [
    {
      EventosId : 1,
       Tema: 'Angular',
       Local: 'Minha casa'
    },
    {
      EventosId : 2,
       Tema: 'Angular2',
       Local: 'Minha casa2'
    },
    {
      EventosId : 3,
       Tema: 'Angular3',
       Local: 'Minha casa3'
    }
  ];*/

  constructor(private http: HttpClient){}

  ngOnInit() {
    this.getEventos();
  }

  getEventos()
  {
    this.http.get('http://localhost:5000/WeatherForecast/Teste').subscribe (
      response => {this.eventos = response;
        console.log(response);
      },
      error => {console.log(error);}

    );
  }

}
