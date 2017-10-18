import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { SpotsComponent } from './components/spots/spots.component';
import { RegisterComponent } from './components/register/register.component';


const appRoutes: Routes = [
    {
        path: '',
        component: LoginComponent,
        //canActivate: [ AuthGuard ]
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'login',
        component: LoginComponent,
    },
    {
        path: 'spots',
        component: SpotsComponent,
    },
    {
        path: 'register',
        component: RegisterComponent
    },
    {
        path: "**",
        component: HomeComponent
    }
];

export const appRoutingProviders: any[] = [];
export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes,{enableTracing:true});