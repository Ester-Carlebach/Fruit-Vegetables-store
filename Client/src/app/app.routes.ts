import { Routes } from '@angular/router';
import { HomeComponent } from '../comps/home/home.component';
import { CartingComponent } from '../comps/carting/carting.component';
import { ProductComponent } from '../comps/product/product.component';
import { LoginComponent } from '../comps/login/login.component';
import { DetailsComponent } from '../comps/details/details.component';
import { CashRegisterComponent } from '../comps/cash-register/cash-register.component';

export const routes: Routes = [
    {path:'',component:HomeComponent},
    {path:'carting',component:CartingComponent},
    {path:'product',component:ProductComponent,},
    {path:'login',component:LoginComponent},
    {path: 'detailes/:pId', component:DetailsComponent, title: 'פרטים נוספים' },
    {path: 'cashRegister', component:CashRegisterComponent, title: 'קופה' }


];
