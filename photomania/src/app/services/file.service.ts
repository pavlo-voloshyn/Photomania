import { Photo } from './../models/photo.interface';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  // API url
  baseApiUrl = "http://localhost:5166/api/"

  constructor(private http: HttpClient) { }

  public upload(file: File, arrTags: string[]):Observable<any> {
      let tags = arrTags.join(';')
      console.log(arrTags)
      console.log(tags)

      const formData = new FormData();
      formData.append("file", file, file.name);

      formData.append("tags", tags);
      return this.http.post(this.baseApiUrl + "file", formData)
  }

  public getAll(): Observable<Photo[]> {
      return this.http.get<Photo[]>(this.baseApiUrl + "file");
  }

  public getMyPhotos(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.baseApiUrl + "file/favorite");
  }

  public addFavorite(imgId?: string) {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("imgId", imgId ? imgId : '');

    return this.http.put(this.baseApiUrl + "file/add-favorite", {}, {params: queryParams} );
  }
}
