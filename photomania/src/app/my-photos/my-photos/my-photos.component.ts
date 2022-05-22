import { FileService } from './../../services/file.service';
import { Photo } from './../../models/photo.interface';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-photos',
  templateUrl: './my-photos.component.html',
  styleUrls: ['./my-photos.component.scss']
})
export class MyPhotosComponent implements OnInit {
  baseUrl = "http://localhost:5166/";
  items: Photo[] = []
  constructor(private fileService: FileService) { }

  ngOnInit(): void {
    this.fileService.getMyPhotos().subscribe(res => {
      console.log(res)
      this.items = res;
    })
  }
}
