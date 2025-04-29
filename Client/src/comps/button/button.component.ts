import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [],
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})
export class ButtonComponent {
//הקלאס שנשלח 
@Input() myClass:String=""
//האם להציג את הכפתןר או לא
@Input() myDid:boolean=false;
//פונקציה מהאבא 
@Output() myFunc=new EventEmitter();
//הפעלת הפונקציה
func(){
  this.myFunc.emit();
}
}
