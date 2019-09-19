import { Component } from '@angular/core';
import { ITag } from '../Tag/tag';
import { TagComponent } from '../Tag/tag.component';
// import { SearchService } from '../Services/search.service';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { TagInputBoxComponent } from '../TagInputBox/tagInputBox.component';

@Component({
  selector: 'tag-search',
  templateUrl: './tagSearch.component.html',
  styleUrls: ['./tagSearch.component.css'],
  
})

export class TagSearchComponent {

     tagInputEditor : FormControl = new FormControl('game-dev bezier-curves');

     constructor(private router: Router) { }
    
     navigateToResults(queryString : string)
     {
        this.router.navigate(['/search'], { queryParams: { q: encodeURIComponent(queryString) } });
     }

     onEnterPressed(event: KeyboardEvent)
     {
         this.navigateToResults(this.tagInputEditor.value);
     }
}