import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_model/User';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {

  user:User;
  galleryOptions:NgxGalleryOptions[];
  galleryImages:NgxGalleryImage[];
  constructor(private userService:UserService,private alertify:AlertifyService,private router:ActivatedRoute) { }

  ngOnInit() {
    this.router.data.subscribe(x=>
      {
        this.user=x['user'];
      })

      this.galleryOptions=[{
        width:'500px',
        height:'500px',
        imagePercent:100,
        thumbnailsColumns:4,
        imageAnimation:NgxGalleryAnimation.Slide,
        preview:false
      }];
      this.galleryImages=this.getImages();
  }

  getImages()
  {
    const imageUrl=[];
    for(let i = 0;i < this.user.photos.length; i++)
    {
      imageUrl.push({
        small:this.user.photos[i].url,
        medium:this.user.photos[i].url,
        large:this.user.photos[i].url,
        description:this.user.photos[i].description,
      });
    }
    return imageUrl;
  }


  
}
