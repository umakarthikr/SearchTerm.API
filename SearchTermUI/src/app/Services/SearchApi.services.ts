import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()

export class SearchApiService {

  constructor(private httpclient: HttpClient) { }
  getUsers(searchString:string): Observable<any> {

    return this.httpclient.get("https://localhost:7146/User/Search?searchString="+searchString)

  }
}
