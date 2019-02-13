import { ViewModel } from './viewModel';
import { Home } from './home';
import { Link } from './link';

export class HomeViewModel extends ViewModel<Home> {
    babysitterShiftLink: string;

    constructor(links: Link[]) {
        super();

        this.links = links;

        this.babysitterShiftLink = this.getBabysitterShiftLink();
    }

    private getBabysitterShiftLink(): string {
        return this.findLink('babysitterShift').href;
    }
}
