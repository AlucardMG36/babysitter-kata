import { ApiError } from './apiError';
import { Link } from './link';

export abstract class ViewModel<T> {
    data: T;
    errors: ApiError[];
    links: Link[];

    public constructor() {
        this.errors = [];
        this.links = [];
    }

    protected findLink(name: string) {
        return this.links.find(l => name === l.name);
    }
}
