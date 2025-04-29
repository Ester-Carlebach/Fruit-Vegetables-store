import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appDir]',
  standalone: true
})
export class DirDirective {

  constructor(private er: ElementRef) { 
  }
// בעת מעבר מגדיל את הכתב
  @HostListener("mouseenter") d()
{
  this.er.nativeElement.style.fontSize ='1.2rem';
}  
// בעת עזיבה מקטין בחזרה
@HostListener("mouseleave") onmouseleave()
{
  this.er.nativeElement.style.fontSize='1rem';
}  
  
}
